public class Company
{
	public string Name
	{
		get;
		set;
	}
	public string CompanyType
	{
		get;
		set;
	}
	public string Address
	{
		get;
		set;
	}
	public string Phone
	{
		get;
		set;
	}
	public string Email
	{
		get;
		set;
	}
	public Company(
		string name,
		string companyType,
		string address,
		string phone,
		string email
	)
	{
		Name = name;
		CompanyType = companyType;
		Address = address;
		Phone = phone;
		Email = email;
	}
}