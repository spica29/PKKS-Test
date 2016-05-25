using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace LufthansaForm
{
    public class XMLSerialization
    {
        public static T ReadXML<T>()
        {
            FileStream stream = null;

            try
            {
                if (File.Exists("lufthansa.xml"))
                {
                    //deserijalizacija xml
                    XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    stream = new FileStream("lufthansa.xml", FileMode.Open, FileAccess.Read);
                    TextReader citac = new StreamReader(stream);
                    T read = (T)deserializer.Deserialize(citac);
                    return (T)read;
                }
                return default(T);
            }
            catch (Exception ex)
            {
               throw new ArgumentException("nije uspjela serijalizacija");
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static void WriteXML<T>(T letovi)
        {
            FileStream stream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                stream = new FileStream("lufthansa.xml", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                serializer.Serialize(writer, letovi);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("nije uspjela serijalizacija");
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
    }
}
