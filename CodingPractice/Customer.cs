class Customer
{
    public string LastName;
    public string FirstName;

    public Customer(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}
