using System;
using System.Windows.Forms;
using System.Xml;

namespace AppAgendaXml
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentXml = new XmlDocument();
            documentXml.Load(@"C:\Users\Diego\source\repos\AppAgendaXml\AppAgendaXml\Agenda.xml");
            XmlNode noTitulo = documentXml.SelectSingleNode("/agenda/titulo");
            return noTitulo.InnerText;
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\Diego\source\repos\AppAgendaXml\AppAgendaXml\Agenda.xml");
            XmlNodeList contatos = documentoXml.SelectNodes("/agenda/contatos/contato");

            foreach (XmlNode contato in contatos)
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoContato = nome + " , " + idade + " , " + id;
                lbxContatos.Items.Add(representacaoContato);
            }
        }

        private void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\Diego\source\repos\AppAgendaXml\AppAgendaXml\Agenda.xml");

            XmlAttribute atributoId = documentoXml.CreateAttribute("id");
            atributoId.Value = "7";

            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "Diego";

            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "26";

            XmlNode novoContato = documentoXml.CreateElement("contato");
            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);
            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);

            documentoXml.Save(@"C:\Users\Diego\source\repos\AppAgendaXml\AppAgendaXml\Agenda.xml");
        }
    }
}
