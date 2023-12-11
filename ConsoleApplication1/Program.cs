using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {



            ServiceReferenceCobro.ZFI_WS_INTERFASE_PAGOS zFI_WS_INTERFASE_PAGOS = new ServiceReferenceCobro.ZFI_WS_INTERFASE_PAGOS();

            ServiceReferenceCobro.ZSFI_WS_PAGOS pago = new ServiceReferenceCobro.ZSFI_WS_PAGOS();

            zFI_WS_INTERFASE_PAGOS.ZSFI_WS_PAGOS = new ServiceReferenceCobro.ZSFI_WS_PAGOS[1];
            zFI_WS_INTERFASE_PAGOS.ZSFI_WS_PAGOS[0] = pago;


            pago.CIA_CLIENTE = "1100";
            pago.PAIS = "DO";
            pago.RNC = "101807724";
            pago.FECHA_PAGO = "05/18/2023";
            pago.NUMERO_PAGO = "111111111P";
            pago.BANCO = "";
            pago.NUM_CUENTA = "13345555";
            pago.MONTO_PAGADO = "500";
            pago.MONEDA_PAGO = "DO";
            pago.ANTICIPO = "0";
            pago.RECIBO = "0";
            pago.SU_DOCUMENTO = "SS30000090";
            pago.FECHA = "05/18/2023";
            pago.COMPROBANTE_FISCAL = "com0001";
            pago.MONEDA = "DO";
            pago.TOTAL_RECIBO = "30000";
            pago.DESCUENTOS = "0";
            pago.VALOR_NETO = "30000";
            pago.NUM_CONTENEDOR = "";
            ServiceReferenceCobro.ZFI_WS_PAGOSClient clientePago = new ServiceReferenceCobro.ZFI_WS_PAGOSClient();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            clientePago.ClientCredentials.UserName.UserName = "WSDEV";
            clientePago.ClientCredentials.UserName.Password = "BjwLv7xqNymRRlJcXlaBdrksGAqyzDJ{zNWToyDJ";
            var resultado = clientePago.ZFI_WS_INTERFASE_PAGOS(zFI_WS_INTERFASE_PAGOS);
            Console.WriteLine(resultado.RESULTADO.MENSAJES[0].MENSAJE);
            clientePago.Close();
            
            
            
            
            
            
            
            ServiceReferencePrice.ZSD_SHCAD_BUSCAR_PRECIOClient cliente = new ServiceReferencePrice.ZSD_SHCAD_BUSCAR_PRECIOClient();
            ServiceReferencePrice.ZSD_BUSCAR_PRECIOS data = new ConsoleApplication1.ServiceReferencePrice.ZSD_BUSCAR_PRECIOS();
            ServiceReferencePrice.ZSDES_MATERIALES mat = new ConsoleApplication1.ServiceReferencePrice.ZSDES_MATERIALES();
           
            //https://vhfdeds4ci.sap.schad.do:44300/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zsd_shcad_buscar_precio/110/zsd_shcad_buscar_precio/zsd_shcad_buscar_precio
            //https://vhfdeds4ci.sap.schad.do:44300/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zfi_ws_pagos/110/zfi_ws_pago/zfi_ws_pago?sap-client=110

            cliente.ClientCredentials.UserName.UserName = "WSDEV";
            cliente.ClientCredentials.UserName.Password = "BjwLv7xqNymRRlJcXlaBdrksGAqyzDJ{zNWToyDJ";
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            mat.MATNR = "SER-000017";
            mat.QTY = 1;
            data.P_MATNR = new ConsoleApplication1.ServiceReferencePrice.ZSDES_MATERIALES[] { mat };
            data.P_TAXNUM = "101002591";
            data.P_VKORG = "1100";
            
           

            cliente.Open();

            var result = cliente.ZSD_BUSCAR_PRECIOS(data);
            var PRECIO = result.IT_PRECIOS;
            cliente.Close();
        }
    }
}
