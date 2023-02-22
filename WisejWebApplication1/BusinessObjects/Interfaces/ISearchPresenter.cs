//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad IPresenter
//Fecha:2/21/2023 2:50:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System.Collections.Generic;
namespace BusinessObjects.Interfaces
{
    public interface ISearchPresenter<T>
    {
        T FindById(object id);
        void Search();
        void DataBind(ISearch senderBusqueda);
        List<T> GetAll();
		IContext Context { get; }
    }
}
