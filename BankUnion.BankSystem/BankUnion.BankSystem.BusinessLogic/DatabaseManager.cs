using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BankUnion.BankSystem.BusinessLogic
{
    public class DatabaseManager
    {
        const string CLIENT_FILE = "ClientDatabase.xml";
        const string LOAN_FILE = "LoanDatabase.xml";
        const string BANK_ACCOUNT_FILE = "BankAccountDatabase.xml";
        const string KEY_STRING = "Key";

        readonly Dictionary<Type, string> _pathways;

        public DatabaseManager()
        {
            _pathways = new Dictionary<Type, string>
            {
                [typeof(Client)] = CLIENT_FILE,
                [typeof(Loan)] = LOAN_FILE,
                [typeof(BankAccount)] = BANK_ACCOUNT_FILE
            };

            CreateXml(CLIENT_FILE);
            CreateXml(LOAN_FILE);
            CreateXml(BANK_ACCOUNT_FILE);
        }

        public void SaveDatabase<TBase>(Dictionary<int, TBase> database)
        {
            if (!(typeof(TBase) == typeof(Client) ||
                typeof(TBase) == typeof(Loan) ||
                typeof(TBase) == typeof(BankAccount)))
            {
                return;
            }

            var path = _pathways[typeof(TBase)];

            if (!File.Exists(path))
            {
                CreateXml(path);
            }

            ClearXml(path);
            var xmlDoc = XDocument.Load(path);
            var fields = typeof(TBase).GetFields();

            foreach (var pair in database)
            {
                var node = new XElement(typeof(TBase).ToString().Split('.').Last());
                node.Add(new XElement(KEY_STRING, pair.Key));

                foreach (var field in fields)
                {
                    node.Add(new XElement(
                        field.Name,
                        field.GetValue(pair.Value)
                        ));
                }

                xmlDoc.Root?.Add(node);
            }

            xmlDoc.Save(path);
        }

        public void ShowDatabase(Type databaseType)
        {
            if (!(databaseType == typeof(Client) ||
                  databaseType == typeof(Loan) ||
                  databaseType == typeof(BankAccount)))
            {
                return;
            }

            var path = _pathways[databaseType];

            if (!File.Exists(path))
            {
                CreateXml(path);
            }

            var xmlDoc = XDocument.Load(path);
            var fields = databaseType.GetFields();
            var nodes = xmlDoc.Descendants(databaseType.ToString().Split('.').Last());

            foreach (var node in nodes)
            {
                Console.WriteLine(KEY_STRING + ": " + node.Element(KEY_STRING)?.Value);

                foreach (var field in fields)
                {
                    Console.WriteLine(field.Name + ": " + node.Element(field.Name)?.Value);
                }

                Console.WriteLine();
            }
        }

        public void DelTuple<TBase>(int key)
        {
            if (!(typeof(TBase) == typeof(Client) ||
                  typeof(TBase) == typeof(Loan) ||
                  typeof(TBase) == typeof(BankAccount)))
            {
                return;
            }

            var path = _pathways[typeof(TBase)];

            if (!File.Exists(path))
            {
                CreateXml(path);
            }

            var xmlDoc = XDocument.Load(path);
            var nodes = xmlDoc.Descendants(typeof(TBase).ToString().Split('.').Last());
            var node = nodes
                .Where(x => x.Descendants(KEY_STRING).First().Value == key.ToString()).First();

            node.Remove();
            xmlDoc.Save(path);
        }

        public void UpdateDB<TBase>(int key)
        {
            if (!(typeof(TBase) == typeof(Client) ||
                  typeof(TBase) == typeof(Loan) ||
                  typeof(TBase) == typeof(BankAccount)))
            {
                return;
            }

            var path = _pathways[typeof(TBase)];

            if (!File.Exists(path))
            {
                CreateXml(path);
            }

            var xmlDoc = XDocument.Load(path);
            var nodes = xmlDoc.Descendants(typeof(TBase).ToString().Split('.').Last());
            var nodesToUpdate = nodes
                .Where(x => x.Descendants(KEY_STRING).First().Value == key.ToString());
            
            if (nodesToUpdate.Any())
            {
                //TODO предложить пользователю ввести новые данные
            }
            else
            {
                //TODO предложить пользователю ввести новые данные
                var newNode = new XElement(typeof(TBase).ToString().Split('.').Last(), "");
                //xmlDoc.Add(newNode);
            }

            xmlDoc.Save(path);
        }

        void CreateXml(string path)
        {
            if (!File.Exists(path))
            {
                var mainNode = path.Split('.').First().Trim();
                var declaration = new XDeclaration("1.0", "utf-8", null);
                var xmlDoc = new XDocument(declaration, new XElement(mainNode));
                xmlDoc.Save(path);
            }
        }

        void ClearXml(string path)
        {
            var xmlDoc = XDocument.Load(path);
            xmlDoc.Root?.RemoveAll();
            xmlDoc.Save(path);
        }
    }
}
