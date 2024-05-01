using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete;
public class ContactManager : IContactService
{
	private readonly IContactDal _contactDal;

	public ContactManager(IContactDal contactDal)
	{
		_contactDal = contactDal;
	}

	public void TDelete(int id)
	{
		_contactDal.Delete(id);
	}

	public List<Contact> TGetAll()
	{
		return _contactDal.GetAll();
	}

	public Contact TGetByID(int id)
	{
		return _contactDal.GetByID(id);
	}

	public void TInsert(Contact t)
	{
		_contactDal.Insert(t);
	}

	public void TUpdate(Contact t)
	{
		_contactDal.Update(t);
	}
}
