using System.IO;
using System.Linq;
using System.Net;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.SqlClient;

using System.Threading.Tasks;
using System;

namespace WebApiRest.Services
{
    public  class CSriws
    {
        public CRespuestaRecepcion RecepcionComprobantePrueba(string xml)
        {
            String respuesta = "";
            CRespuestaRecepcion RespuestaRecepcionPrueba = new CRespuestaRecepcion();
            var soapEnvelopeXml = new XmlDocument();

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline?wsdl");

            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            soapEnvelopeXml.LoadXml(new CSoapXML().RecepcionComprobanteSoap(xml));

            using (Stream requestStream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(requestStream);
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 ;
            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    respuesta = rd.ReadToEnd();

                    var soapResult = XDocument.Parse(respuesta);

                    var responseXml = soapResult.Descendants("RespuestaRecepcionComprobante").ToList();
                    foreach (var xmlDoc in responseXml)
                    {
                        RespuestaRecepcionPrueba = (CRespuestaRecepcion)DeserializeFromXElement(xmlDoc, typeof(CRespuestaRecepcion));

                    }
                }
            }
            return RespuestaRecepcionPrueba;
        }
        public CRespuestaAutorizacion AutorizacionComprobantePrueba(string claveAcceso)
        {
            CRespuestaAutorizacion RespuestaAutorizacion = new CRespuestaAutorizacion();
            try
            {
                String respuesta = "";

                var soapEnvelopeXml = new XmlDocument();

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl");

                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";


                soapEnvelopeXml.LoadXml(new CSoapXML().AutorizacionComprobanteSoap(claveAcceso));

                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(requestStream);
                }

                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {

                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        respuesta = rd.ReadToEnd();
                        var soapResult = XDocument.Parse(respuesta);
                        var responseXml = soapResult.Descendants("RespuestaAutorizacionComprobante").ToList();

                        foreach (var xmlDoc in responseXml)
                        {
                            RespuestaAutorizacion = (CRespuestaAutorizacion)DeserializeFromXElement(xmlDoc, typeof(CRespuestaAutorizacion));

                        }

                    }
                }

                return RespuestaAutorizacion;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public CRespuestaRecepcion RecepcionComprobanteooffline(string xml)
        {

            CRespuestaRecepcion RespuestaRecepcion = new CRespuestaRecepcion();
            String respuesta = "";

            var soapEnvelopeXml = new XmlDocument();

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https://cel.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline?wsdl");

            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";


            soapEnvelopeXml.LoadXml(new CSoapXML().RecepcionComprobanteSoap(xml));

            using (Stream requestStream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(requestStream);
            }

            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    respuesta = rd.ReadToEnd();

                    var soapResult = XDocument.Parse(respuesta);

                    var responseXml = soapResult.Descendants("RespuestaRecepcionComprobante").ToList();
                    foreach (var xmlDoc in responseXml)
                    {
                        RespuestaRecepcion = (CRespuestaRecepcion)DeserializeFromXElement(xmlDoc, typeof(CRespuestaRecepcion));

                    }
                }
            }

            return RespuestaRecepcion;
        }
        public CRespuestaAutorizacion AutorizacionComprobanteoffline(string claveAcceso)
        {
            string error;
            CRespuestaAutorizacion RespuestaAutorizacion = new CRespuestaAutorizacion();
            try
            {
                String respuesta = "";

                var soapEnvelopeXml = new XmlDocument();

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("https://cel.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl");

                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";


                soapEnvelopeXml.LoadXml(new CSoapXML().AutorizacionComprobanteSoap(claveAcceso));

                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(requestStream);
                }

                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {

                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        respuesta = rd.ReadToEnd();

                        var soapResult = XDocument.Parse(respuesta);

                        var responseXml = soapResult.Descendants("RespuestaAutorizacionComprobante").ToList();

                        foreach (var xmlDoc in responseXml)
                        {
                            RespuestaAutorizacion = (CRespuestaAutorizacion)DeserializeFromXElement(xmlDoc, typeof(CRespuestaAutorizacion));
                        }

                    }

                }

                return RespuestaAutorizacion;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
        public void xmlAutorizado( String patchCData, String patchOUT, string estadoAutorizado, string numeroAutorizado, string fechaAutorizado)
        {

            try
            {

                if (!string.IsNullOrEmpty(estadoAutorizado) && !string.IsNullOrEmpty(numeroAutorizado) && !string.IsNullOrEmpty(fechaAutorizado))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                    XmlNode root = doc.DocumentElement;
                    doc.InsertBefore(xmlDeclaration, root);
                    XmlElement raizAutorizacion = doc.CreateElement("autorizacion");
                    doc.AppendChild(raizAutorizacion);
                    XmlElement estado = doc.CreateElement("estado");
                    estado.AppendChild(doc.CreateTextNode(estadoAutorizado));
                    raizAutorizacion.AppendChild(estado);

                    XmlElement numeroAutorizacion = doc.CreateElement("numeroAutorizacion");
                    numeroAutorizacion.AppendChild(doc.CreateTextNode(numeroAutorizado));
                    raizAutorizacion.AppendChild(numeroAutorizacion);

                    XmlElement fechaAutorizacion = doc.CreateElement("fechaAutorizacion");
                    fechaAutorizacion.SetAttribute("class", "fechaAutorizacion");
                    fechaAutorizacion.AppendChild(doc.CreateTextNode(fechaAutorizado));
                    raizAutorizacion.AppendChild(fechaAutorizacion);
                    string xmlText = File.ReadAllText(patchCData);
                    var cdata = new XmlDocument();
                    cdata.LoadXml(xmlText);

                    XmlElement comprobante = doc.CreateElement("comprobante");
                    comprobante.AppendChild(doc.CreateCDataSection(xmlText.ToString()));
                    raizAutorizacion.AppendChild(comprobante);

                    XmlElement mensaje = doc.CreateElement("mensajes");
                    raizAutorizacion.AppendChild(mensaje);
                    doc.Save(patchOUT);
                }

            }
            catch (Exception )
            {

         
            }

        }
        public void xmlnoAutorizado(String patchCData, String patchOUT)
        {


            CRespuestaAutorizacion RespuestaAutorizacion = new CRespuestaAutorizacion();


            foreach (var Respuesta_Autorizacion in RespuestaAutorizacion.Comprobantes)
            {
                if (Respuesta_Autorizacion.Estado.Equals("NO AUTORIZADO"))
                {
                    XmlDocument doc = new XmlDocument();

                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                    XmlNode root = doc.DocumentElement;
                    doc.InsertBefore(xmlDeclaration, root);
                    XmlElement raizAutorizacion = doc.CreateElement("autorizacion");
                    doc.AppendChild(raizAutorizacion);

                    XmlElement estado = doc.CreateElement("estado");
                    estado.AppendChild(doc.CreateTextNode(Respuesta_Autorizacion.Estado));
                    raizAutorizacion.AppendChild(estado);

                    XmlElement fechaAutorizacion = doc.CreateElement("fechaAutorizacion");
                    fechaAutorizacion.SetAttribute("class", "fechaAutorizacion");
                    fechaAutorizacion.AppendChild(doc.CreateTextNode(Respuesta_Autorizacion.FechaAutorizacion));
                    raizAutorizacion.AppendChild(fechaAutorizacion);

                    string xmlText = File.ReadAllText(patchCData);
                    var cdata = new XmlDocument();
                    cdata.LoadXml(xmlText);

                    XmlElement comprobante = doc.CreateElement("comprobante");
                    comprobante.AppendChild(doc.CreateCDataSection(xmlText.ToString()));
                    raizAutorizacion.AppendChild(comprobante);
                    XmlNode nodomensaje = doc.DocumentElement;

                    XmlNode mensajes = doc.CreateElement("mensajes");
                    XmlNode mensaje = doc.CreateElement("mensaje");
                    XmlNode mensaje1 = doc.CreateElement("mensaje");

                    doc.Save(patchOUT);
                }
            }
        }
        public object DeserializeFromXElement(XElement element, Type t)
        {
            try
            {
                using (XmlReader reader1 = element.CreateReader())
                {
                    XmlSerializer serializer = new XmlSerializer(t);
                    return serializer.Deserialize(reader1);
                }
            }
            catch (Exception ex)
            {
                string g = ex.Message;
                string k = ex.ToString();
                return null;
            }



        }
    }
}
