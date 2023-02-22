//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad IPresenter
//Fecha:2/22/2023 8:17:55 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

namespace BusinessObjects.Interfaces
{
	public interface IDataSource 
	{
        object DataGridSource { get; set; }
    }

    public interface IValueToSearch
    {
        string ValueToSearch { get; set; }
    }

    public interface ISearch : IDataSource, IValueToSearch
    {
        object Id { get; set; }

    }
}
