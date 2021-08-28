using FikaAmazonAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FikaAmazonAPI
{
    public class AmazonConnection
    {
        private AmazonCredential Credentials { get; set; }

        

        public OrderService Orders => this._Orders ?? throw _NoCredentials;
        public ReportService Reports => this._Reports ?? throw _NoCredentials;
        public SolicitationService Solicitations => this._Solicitations ?? throw _NoCredentials;
        public FinancialService Financial => this._Financials ?? throw _NoCredentials;


        private OrderService _Orders { get; set; }
        private ReportService _Reports { get; set; }
        private SolicitationService _Solicitations { get; set; }
        private FinancialService _Financials { get; set; }



        private UnauthorizedAccessException _NoCredentials = new UnauthorizedAccessException($"Error, you cannot make calls to Amazon without credentials!");


        public AmazonConnection(AmazonCredential Credentials)
        {
            this.Authenticate(Credentials);
        }

        public void Authenticate(AmazonCredential Credentials)
        {
            if (this.Credentials == default(AmazonCredential))
                Init(Credentials);
            else
                throw new InvalidOperationException("Error, you are already authenticated to amazon in this AmazonConnection, dispose of this connection and create a new one to connect to a different account.");
        }

        private void Init(AmazonCredential Credentials)
        {
            this.Credentials = Credentials;

            this._Orders = new OrderService(this.Credentials);
            this._Reports = new ReportService(this.Credentials);
            this._Solicitations = new SolicitationService(this.Credentials);
            this._Financials = new FinancialService(this.Credentials);
        }
    }
}
