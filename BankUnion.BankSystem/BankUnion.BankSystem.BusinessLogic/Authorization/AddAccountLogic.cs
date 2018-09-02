using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace BankUnion.BankSystem.BusinessLogic.Authorization
{
    public class AddAccountLogic
    {
        private const string XmlName = "Account.xml";
        public Account CreateNewAccount(AccountType type)
        {
            WriteLine("Enter the name for account:");
            var name = ReadLine();

            WriteLine("Enter the password for account:");
            var password = ReadLine();
            var id = GenerateId();

            var account = new Account()
            {
                Id = id,
                Name = name,
                Password = password,
                TypeAccount = type
            };

            SaveAccountInFile(account);

            return account;
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void SaveAccountInFile(Account account)
        {
            if (!File.Exists(XmlName)) {
                var xdoc = new XDocument();
                xdoc.Add(new XElement("Accounts"));
                xdoc.Save(XmlName);
            }

            var docXml = XDocument.Load(XmlName);
            var element = GetNewXmlElement(account);
            var root = docXml.Element("Accounts");
            root.Add(element);
            docXml.Save(XmlName);
        }

        private XElement GetNewXmlElement(Account account)
        {
            var element = new XElement("Account");
            var id = new XAttribute("Id", account.Id);
            var name = new XElement("Name", account.Name);
            var password = new XElement("Password", GetHashPassword(account.Password));
            var type = new XElement("AccountType", account.TypeAccount);

            element.Add(id);
            element.Add(name);
            element.Add(password);
            element.Add(type);

            return element;
        }

        private string GetHashPassword(string password)
        {
            var algorithm = MD5.Create();  
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString();
        }

        public bool Authorization(string login, string password)
        {
            var algorithm = MD5.Create();
            var hash = GetHashPassword(password);

            var xdoc = XDocument.Load(XmlName);
            foreach (var item in xdoc.Element("Accounts").Elements("Account"))
            {
                var id = item.Attribute("Id");
                var accountName = item.Element("Name");
                var accountPassword = item.Element("Password");

                if (Equals(login, accountName.Value) && Equals(hash.ToString(), accountPassword.Value))
                    return true;
            }
            return false;
        }
    }
}
