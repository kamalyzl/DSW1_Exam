using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFExamen
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract] public interface IService1
    {
        [OperationContract] IEnumerable<Solicitudes> Solicitudes();
        [OperationContract] IEnumerable<Actividad> Actividades();
        [OperationContract] string Agregar(Solicitud reg);
        [OperationContract] string Eliminar(string nsolicitud);

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Actividad
    {
        [DataMember] public string idact { get; set; }
        [DataMember] public string desact { get; set; }
        [DataMember] public string idcateg { get; set; }
        [DataMember] public string fecha { get; set; }
        [DataMember] public string vacantes { get; set; }
    }

    [DataContract]
    public class Categoria
    {
        [DataMember] public string idcateg { get; set; }
        [DataMember] public string descateg { get; set; }
    }

    [DataContract]
    public class Solicitud
    {
        [DataMember] public string nsolicitud { get; set; }
        [DataMember] public string fsolicitud { get; set; }
        [DataMember] public string idact { get; set; }
        [DataMember] public string dni { get; set; }
        [DataMember] public string nombre { get; set; }
        [DataMember] public string email { get; set; }
    }

    public class Solicitudes
    {
        [DataMember] public string nsolicitud { get; set; }
        [DataMember] public string fsolicitud { get; set; }
        [DataMember] public string desact { get; set; }
        [DataMember] public string descat { get; set; }
        [DataMember] public string dni { get; set; }
        [DataMember] public string nombre { get; set; }
        [DataMember] public string email { get; set; }
    }
}
