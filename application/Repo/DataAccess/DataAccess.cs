// using Shared;
// using System;
// using System.IO;
// using System.Runtime.Serialization;
// using System.Runtime.Serialization.Formatters.Binary;

// namespace Repo.DataAccess
// {

//     public class DataAccess : IDataAccess
//     {
//         public List<Cart> CartList { get; set; }
//         public List<Offer> OfferList { get; set; }
//         public List<Client> ClientList { get; set; }
//         public List<Administrator> AdminList { get; set; }

//         object IDataAccess.DeleteRecord(int id, string name)
//         {
//             throw new NotImplementedException();
//         }

//         object IDataAccess.GetRecord(int id, string name)
//         {
//             throw new NotImplementedException();
//         }

//         int IDataAccess.SaveRecord(object o)
//         {
//             throw new NotImplementedException();
//         }

//         int IDataAccess.UpdateRecord(object o)
//         {
//             throw new NotImplementedException();
//         }

//         private bool SerializeObject<T>(List<T> list, string path)
//         {
//             try
//             {
//                 IFormatter formatter = new BinaryFormatter();
//                 Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
//                 formatter.Serialize(stream, list);
//                 stream.Close();
//             }
//             catch (Exception e)
//             {
//                 throw new Exception("Pluje wyjatkiem na serializacji: " + e);
//             }
//             return true;
//         }

//         private bool DeserializeObject<T>(string path)
//         {
//             try
//             {
//                 List<T> list = new List<T>();
//                 IFormatter formatter = new BinaryFormatter();
//                 Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
//                 list = (List<T>)formatter.Deserialize(stream);
//                 stream.Close();
//             }
//             catch (Exception e)
//             {
//                 throw new Exception("Pluje wyjatkiem na deserializacji: " + e);
//             }
//             return true;
//         }
//     }

// }