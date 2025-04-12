using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmToken : Form
    {
        public frmToken()
        {
            InitializeComponent();
        }

        private void frmToken_Load(object sender, EventArgs e)
        {
            var clienteRest = new RestClient(Constantes.URI_TOKEN);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", Constantes.CONTENT_TYPE);
            request.AddParameter("grant_type", Constantes.GRANT_TYPE);
            request.AddParameter("scope", Constantes.SCOPE);
            request.AddParameter("client_id", Constantes.CLIENT_ID);
            request.AddParameter("client_secret", Constantes.CLIENT_SECRET);

            IRestResponse restResponseToken = clienteRest.Execute(request);
            txtResponse.Text = restResponseToken.Content;

            JsonDeserializer deserial = new JsonDeserializer();
            JsonResponseToken jsonResponseToken = deserial.Deserialize<JsonResponseToken>(restResponseToken);
            txtToken.Text = jsonResponseToken.Access_token;
        }

    }
}
