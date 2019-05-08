using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace City_Traffic_Simulation_Application
{
    class SerializeData
    {
        private Stream stream = null;
        private BinaryFormatter bformatter = null;
        private string txtfileName = "";

        // the construcor
        public SerializeData(string filename)
        {
            this.txtfileName = filename;
            stream = File.Open(txtfileName, FileMode.Create);
            bformatter = new BinaryFormatter();
        }

        //methods to serialize
        public void SerialiseObjects(object objecttoserialize)
        {
            bformatter.Serialize(stream, objecttoserialize);
        }
        //methods to deserialize
        public void DeSerialiseObjects()
        {
            object objectTodeserialise = null;
            stream = File.Open(txtfileName, FileMode.Open);
            try
            {
                while (stream.CanSeek)
                {
                    objectTodeserialise = (object)bformatter.Deserialize(stream);
                    if(objectTodeserialise is Car)
                    {
                        Car toyota = (Car)objectTodeserialise;
                        Console.WriteLine(toyota.id.ToString() + toyota.Speed.ToString());
                        Console.WriteLine("end of file");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // closing the stream
        public void closeStream()
        {
            stream.Close();
        }
    }

}
