using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class ContactListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ContactListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Contacts Command.
		private ICommand getContactsCommand;
		public ICommand GetContactsCommand
		{
			get => getContactsCommand ?? (getContactsCommand = new Command(async () => await ExecuteGetContactsCommand()));
		}
		private async Task ExecuteGetContactsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IContactService service = new ContactService();
			Helper.Helper.CompanyId = 1;
			Response = await service.GetContactsAsync(new Models.ContactRequest()
			{ CompanyId = Helper.Helper.CompanyId });

			var contacts = new ContactList();
			string firstNameCharacter = string.Empty;
			List<ContactList> contactsList = new List<ContactList>();
			for (int i = 0; i < Response.Count; i++)
			{
				Models.ContactResponse contact = Response[i];
				if (string.IsNullOrWhiteSpace(firstNameCharacter))
					firstNameCharacter = contact.Name.Substring(0, 1).ToLower();

				if (firstNameCharacter.EndsWith(contact.Name.Substring(0, 1).ToLower()))
				{
					contacts.Add(contact);
					if (i.Equals(Response.Count - 1))
					{
						contacts.Heading = firstNameCharacter.ToUpper();
						contactsList.Add(contacts);
					}
				}
				else
				{
					if (contacts.Count > 0)
					{
						contacts.Heading = firstNameCharacter.ToUpper();
						contactsList.Add(contacts);

						contacts = new ContactList();
						contacts.Add(contact);
						firstNameCharacter = contact.Name.Substring(0, 1).ToLower();
					}
				}
			}
			ListOfContact = CopyListOfContact = contactsList;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Contacts Command.
		private ICommand searchContactsCommand;
		public ICommand SearchContactsCommand
		{
			get => searchContactsCommand ?? (searchContactsCommand = new Command<string>(async (searchText) => await ExecuteSearchContactsCommand(searchText)));
		}
		private async Task ExecuteSearchContactsCommand(string searchText)
		{
			if (CopyListOfContact == null || CopyListOfContact.Count == 0 || string.IsNullOrWhiteSpace(searchText)) return;
			if (searchText.Length >= 3)
			{
				var response = Response.Where(x => x.Name.ToLower().Contains(searchText.ToLower())).ToList();
				if (response?.Count > 0)
				{
					var contacts = new ContactList();
					string firstNameCharacter = string.Empty;
					List<ContactList> contactsList = new List<ContactList>();
					for (int i = 0; i < response.Count; i++)
					{
						Models.ContactResponse contact = response[i];
						if (string.IsNullOrWhiteSpace(firstNameCharacter))
							firstNameCharacter = contact.Name.Substring(0, 1).ToLower();

						if (firstNameCharacter.EndsWith(contact.Name.Substring(0, 1).ToLower()))
						{
							contacts.Add(contact);
							if (i.Equals(response.Count - 1))
							{
								contacts.Heading = firstNameCharacter.ToUpper();
								contactsList.Add(contacts);
							}
						}
						else
						{
							if (contacts.Count > 0)
							{
								contacts.Heading = firstNameCharacter.ToUpper();
								contactsList.Add(contacts);

								contacts = new ContactList();
								contacts.Add(contact);
								firstNameCharacter = contact.Name.Substring(0, 1).ToLower();
							}
						}
					}
					ListOfContact = contactsList;
				}
				else
					ListOfContact = null;
			}
			if (searchText.Length == 0)
				ListOfContact = CopyListOfContact;
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private List<ContactList> _listOfContact;
		public List<ContactList> ListOfContact
		{
			get { return _listOfContact; }
			set
			{
				_listOfContact = value;
				base.OnPropertyChanged();
			}
		}

		public List<ContactList> CopyListOfContact { get; set; }
		List<Models.ContactResponse> Response { get; set; }
		#endregion
	}
}

public class ContactList : List<NoffaPlus.Models.ContactResponse>
{
	public string Heading { get; set; }
	public List<NoffaPlus.Models.ContactResponse> Contacts => this;
}
