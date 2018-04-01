using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Imposto.Core.Domain
{
    [Serializable]
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }

        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }
        public int Desconto { get; set; }

        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            try
            {
                String[] sudeste = { "SP", "MG", "ES", "RJ" };

                this.NumeroNotaFiscal = 99999;
                this.Serie = new Random().Next(Int32.MaxValue);
                this.NomeCliente = pedido.NomeCliente;

                this.EstadoDestino = pedido.EstadoOrigem;
                this.EstadoOrigem = pedido.EstadoDestino;

                if (sudeste.Contains(this.EstadoDestino))
                    this.Desconto = 10;
                else
                    this.Desconto = 0;

                foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
                {
                    NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
                    if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    if (this.EstadoDestino == this.EstadoOrigem)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18;
                    }
                    else
                    {
                        notaFiscalItem.TipoIcms = "10";
                        notaFiscalItem.AliquotaIcms = 0.17;
                    }
                    if (notaFiscalItem.Cfop == "6.009")
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                    }
                    else
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                    }
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                    if (itemPedido.Brinde)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18;
                        notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                        notaFiscalItem.BaseIPI = itemPedido.ValorItemPedido;
                        notaFiscalItem.AliquotaIPI = 0;
                        notaFiscalItem.ValorIPI = 0;

                    }
                    else
                    {
                        notaFiscalItem.BaseIPI = itemPedido.ValorItemPedido;
                        notaFiscalItem.AliquotaIPI = 0.1;
                        notaFiscalItem.ValorIPI = notaFiscalItem.BaseIPI * notaFiscalItem.AliquotaIPI;
                    }
                    notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                    notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

                    this.ItensDaNotaFiscal.Add(notaFiscalItem);
                }

                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (StreamWriter writer = new StreamWriter("C:\\NotasFiscais\\" + this.NumeroNotaFiscal + ".xml"))
                {
                    serializer.Serialize(writer, this);
                }

                using (SqlConnection con = new SqlConnection("Server=(localdb)\\Lourival;Database=teste;Trusted_Connection=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@pId", SqlDbType.Int).Value = this.Id;
                        cmd.Parameters.Add("@pNumeroNotaFiscal", SqlDbType.Int).Value = this.NumeroNotaFiscal;
                        cmd.Parameters.Add("@pSerie", SqlDbType.Int).Value = this.Serie;
                        cmd.Parameters.Add("@pNomeCliente", SqlDbType.VarChar).Value = this.NomeCliente;
                        cmd.Parameters.Add("@pEstadoDestino", SqlDbType.VarChar).Value = this.EstadoDestino;
                        cmd.Parameters.Add("@pEstadoOrigem", SqlDbType.VarChar).Value = this.EstadoOrigem;
                        cmd.Parameters.Add("@pDesconto", SqlDbType.Int).Value = this.Desconto;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        foreach (NotaFiscalItem item in this.ItensDaNotaFiscal)
                        {
                                using (SqlCommand cmd2 = new SqlCommand("P_NOTA_FISCAL_ITEM", con))
                                {
                                    cmd2.CommandType = CommandType.StoredProcedure;

                                    cmd2.Parameters.Add("@pId", SqlDbType.Int).Value = item.Id;
                                    cmd2.Parameters.Add("@pIdNotaFiscal", SqlDbType.Int).Value = item.IdNotaFiscal;
                                    cmd2.Parameters.Add("@pCfop", SqlDbType.VarChar).Value = item.Cfop;
                                    cmd2.Parameters.Add("@pTipoIcms", SqlDbType.Decimal).Value = item.TipoIcms;
                                    cmd2.Parameters.Add("@pBaseIcms", SqlDbType.Decimal).Value = item.BaseIcms;
                                    cmd2.Parameters.Add("@pAliquotaIcms", SqlDbType.Decimal).Value = item.AliquotaIcms;
                                    cmd2.Parameters.Add("@pValorIcms", SqlDbType.Decimal).Value = item.ValorIcms;
                                    cmd2.Parameters.Add("@pBaseIPI", SqlDbType.Decimal).Value = item.BaseIPI;
                                    cmd2.Parameters.Add("@pAliquotaIPI", SqlDbType.Decimal).Value = item.AliquotaIPI;
                                    cmd2.Parameters.Add("@pValorIPI", SqlDbType.Decimal).Value = item.ValorIPI;
                                    cmd2.Parameters.Add("@pNomeProduto", SqlDbType.VarChar).Value = item.NomeProduto;
                                    cmd2.Parameters.Add("@pCodigoProduto", SqlDbType.VarChar).Value = item.CodigoProduto;

                                   cmd2.ExecuteNonQuery();

                                }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

