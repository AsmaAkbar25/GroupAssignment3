using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.IO.Pipes;
using System.ComponentModel;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<User> usersList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                usersList.Add(users.GetValue(i));
            }
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.WriteObject(fileStream, usersList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            var deserializedUsers = new SLL();
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                var ans = serializer.ReadObject(stream);
                var listOfUsersFromFile = ans as List<User>;
                foreach(var user in listOfUsersFromFile)
                {
                    deserializedUsers.AddLast(user);
                }
                
                return deserializedUsers;
            }
        }
    }
}
