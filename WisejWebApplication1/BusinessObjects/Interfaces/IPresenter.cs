//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Interface que debe implementar la clase Presenter
//Fecha:2/22/2023 8:17:55 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BusinessObjects.Interfaces
{
    public delegate void Validate();
    public delegate void RaiseRefresh();
    
    public interface ISave
    {
        bool Save();
    }

    public interface IDelete
    {
        bool Delete();
    }

    public interface IAdd
    {
        void Add();
    }
    


    public interface IPresenter: IAdd,ISave,IDelete
    {
        event Validate BeforeSave;
        event Validate AfterSave;
        ICollection<ValidationResult> ValidationResult { get; set; }
        bool Find(object Id);
        bool Find(params object[] sender);
        void FillDataSource();
        void Undo();
        DataTable GetDataTable();
    }
}
