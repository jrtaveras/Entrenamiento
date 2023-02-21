//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad IPresenter
//Fecha:2/21/2023 9:15:49 AM
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
