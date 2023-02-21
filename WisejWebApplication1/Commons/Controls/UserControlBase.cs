//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: control generico base 
//Fecha:2/21/2023 9:02:53 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using Wisej.Web;
using BusinessObjects.Interfaces;

namespace Common.Controls {
 public partial class UserControlBase : Wisej.Web.UserControl
    {
		public string Title { get; set; }

		public string MenuItem { get; set; }

		protected IContext _context;
		CultureInfo _cultureInfo;

		public UserControlBase()
		{
			InitializeComponent();
		}
		public UserControlBase(IContext context)
		{
			_context = context;
			_cultureInfo = Application.CurrentCulture;
			if (string.IsNullOrEmpty(_context.LocalizationName))
				throw new ArgumentException("Debe proporcionar el localizacionName ejemplo es-DO!!");

			if (_context.ResourceManager == null)
				throw new ArgumentException("Debe proporcionar un resource manager!!");

		}

		public virtual string GetCreated()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.CreatedBy), _cultureInfo) ?? CommonConstants.CreatedBy;
		}

		public virtual string GetModified()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.ModifiedBy), _cultureInfo) ?? CommonConstants.ModifiedBy;
		}

		public virtual string GetMessageSavedFields()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.MessageSavedFields), _cultureInfo) ?? CommonConstants.MessageSavedFields;
		}

		public virtual string GetMessageNotice()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.MessageNotice), _cultureInfo) ?? CommonConstants.MessageNotice;
		}

		public virtual string GetMessageException()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.MessageExcepcion), _cultureInfo) ?? CommonConstants.MessageExcepcion;
		}

		public virtual string GetMessageDeletedFields()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.MessageDeletedFields), _cultureInfo) ?? CommonConstants.MessageDeletedFields;
		}

		public virtual string GetMessageFinding()
		{
			return _context.ResourceManager.GetString(nameof(CommonConstants.MessageFinding), _cultureInfo) ?? CommonConstants.MessageFinding;
		}

		public virtual string GetTitle()
		{
			return _context.ResourceManager.GetString(Title) ?? Title;
		}
	}
}
