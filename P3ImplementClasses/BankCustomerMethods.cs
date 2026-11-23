
namespace Classes_M3;

public partial class BankCustomer
{
    // Return the full name
    public string ReturnFullName()
    {
        return $"{FirstName} {LastName}";
    }

    // Update customer name
    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Display customer information
    public string DisplayCustomerInfo()
    {
        return $"Customer ID: {CustomerId}, Name: {ReturnFullName()}";
    }
}
