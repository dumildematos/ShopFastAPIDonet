using System;
using ShopFastAPIDonet.Domain.Validations;

namespace ShopFastAPIDonet.Domain.Entities
{
	public sealed class Person
	{
		public int  Id { get; private set; }
		public string Name { get; private  set; }
		public string Document { get; private set; }
		public string Phone { get; private set; }

		public Person(string document, string name, string phone)
		{
			Validation(document, name, phone);
		}

		public Person(int id, string document, string name, string phone)
		{
			DomainValidationException.When(id <= 0, "Invalid Id");
            Id = id;
            Validation(document, name, phone);
		}

		private void Validation(string document, string name, string phone)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name), "Name should be informed");
			DomainValidationException.When(string.IsNullOrEmpty(document), "Document should be informed");
			DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone should be informed");

			Name = name;
			Document = document;
			Phone = phone;
		}
	}
}

