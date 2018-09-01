using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUnion.BankSystem.BusinessLogic
{
    class  ClientDepartment : IDisposable
    {
        private static ClientDepartment _clientDepartment;
        public static Dictionary<int, Client> ClientBase = new Dictionary<int, Client>();

        private ClientDepartment()
        { }

        public static ClientDepartment GetClientDepartment()
        {
            if (_clientDepartment == null)
            {
                _clientDepartment = new ClientDepartment();
            }
            return _clientDepartment;
        }

        public void RegisterClient()
        {

        }

        public void CheckLoanHistory()
        {

        }

        public void Dispose()
        {

        }
    }
}
