using System;
using System.IO;
using System.Threading.Tasks;
using es.mityc.firmaJava.libreria.utilidades;
using es.mityc.firmaJava.libreria.xades;
using es.mityc.javasign.pkstore;
using es.mityc.javasign.pkstore.keystore;
using es.mityc.javasign.trust;
using es.mityc.javasign.xml.refs;
using es.mityc.javasign.xml.xades.policy;
using java.io;
using java.security;
using java.security.cert;
using java.util;
using javax.xml.parsers;
using org.w3c.dom;
namespace WebApiRest.Services
{
    public class PassStoreKS : IPassStoreKS
    {
        private string _password;

        public PassStoreKS(string password)
        {
            _password = password;
        }

        public char[] getPassword(X509Certificate certificate, string alias)
        {
            return _password.ToCharArray();
        }

        public class Signer
        {
            private X509Certificate _LoadCertificate(string path, string password, out PrivateKey privateKey, out Provider provider)
            {
                X509Certificate certificate = null;
                provider = null;
                privateKey = null;

                KeyStore ks = KeyStore.getInstance("PKCS12");
                ks.load(new BufferedInputStream(new FileInputStream(path)), password.ToCharArray());
                IPKStoreManager storeManager = new KSStore(ks, new PassStoreKS(password));
                List certificates = storeManager.getSignCertificates();

                if (certificates.size() >= 1)
                {

                    var securityDataIssuer = false;
                    var bancocentralDataIssuer = false;
                    var anfaDataIssuer = false;
                    for (var i = 0; i < certificates.size(); i++)
                    {
                        var c = (X509Certificate)certificates.get(i);

                        if (c.getIssuerDN().getName().ToUpper().Contains("SECURITY DATA"))
                        {
                            securityDataIssuer = true;
                            break;
                        }
                        else if (c.getIssuerDN().getName().ToUpper().Contains("BANCO CENTRAL"))
                        {
                            bancocentralDataIssuer = true;
                            break;
                        }
                        else if (c.getIssuerDN().getName().ToUpper().Contains("ANFAC AUTORIDAD DE CERTIFICACION ECUADOR C.A."))
                        {
                            anfaDataIssuer = true;
                            break;
                        }
                    }

                    if (securityDataIssuer || anfaDataIssuer)
                        certificate = (X509Certificate)certificates.get(0);
                    else if (bancocentralDataIssuer)
                        certificate = (X509Certificate)certificates.get(1);



                    privateKey = storeManager.getPrivateKey(certificate);
                    provider = storeManager.getProvider(certificate);
                    return certificate;
                }
                return certificate;

 
            }

            public void Sign(string unsignedXmlPath, string signedXmlPath, string pfxPath, string pfxPassword)
            {


                PrivateKey privateKey;
                Provider provider;
                X509Certificate certificate = _LoadCertificate(pfxPath, pfxPassword, out privateKey, out provider);

                if (certificate != null)
                {
                    TrustFactory.instance = es.mityc.javasign.trust.TrustExtendFactory.newInstance();
                    TrustFactory.truster = es.mityc.javasign.trust.MyPropsTruster.getInstance();
                    PoliciesManager.POLICY_SIGN = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();
                    PoliciesManager.POLICY_VALIDATION = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();
                    com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl s = new com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl();
                    DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
                    dbf.setNamespaceAware(true);
                    Document unsignedDocument = dbf.newDocumentBuilder().parse(new BufferedInputStream(new FileInputStream(unsignedXmlPath)));

                    DataToSign dataToSign = new DataToSign();
                    dataToSign.setXadesFormat(EnumFormatoFirma.XAdES_BES);
                    dataToSign.setEsquema(XAdESSchemas.XAdES_132);
                    dataToSign.setXMLEncoding("UTF-8");
                    dataToSign.setEnveloped(true);
                    dataToSign.addObject(new ObjectToSign(new InternObjectToSign("comprobante"), "contenido comprobante", null, "text/xml", null));
                    dataToSign.setParentSignNode("comprobante");
                    dataToSign.setDocument(unsignedDocument);

                    Object[] res = new FirmaXML().signFile(certificate, dataToSign, privateKey, provider);

                    FileOutputStream fs = new FileOutputStream(signedXmlPath);
                    UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], fs, true);
                    fs.close();

                }

            }
        }
    }
}
