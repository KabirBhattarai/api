using Microsoft.AspNetCore.Mvc;

namespace New_folder.Controllers;

public class BankAccountController : ControllerBase
{
    public static List<BankAccount> BankAccounts = new List<BankAccount>();

    [HttpPost("/api/bankaccount")]
    public IActionResult Create([FromBody] BankAccountDto a)
    {
        var account = new BankAccount
        {
            Id = BankAccounts.Count + 1,
            AccountName = a.AccountName,
            AccountNumber = a.AccountNumber,
            Balance = a.Balance
        };

        BankAccounts.Add(account);
        return Ok(account);
    }

    [HttpGet("/api/bankaccount")]
    public IActionResult GetAll([FromQuery] BankAccountFilterDto filter)
    {
        var accounts = BankAccounts.Where(x =>
            (string.IsNullOrEmpty(filter.AccountName) || x.AccountName.Contains(filter.AccountName)) &&
            (string.IsNullOrEmpty(filter.AccountNumber) || x.AccountNumber.Contains(filter.AccountNumber))
        ).ToList();
        return Ok(accounts);
    }

    [HttpGet("/api/bankaccount/{id}")]
    public IActionResult GetById(int id)
    {
        var account = BankAccounts.FirstOrDefault(x => x.Id == id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(account);
    }

    [HttpPut("/api/bankaccount/{id}")]
    public IActionResult Update(int id, [FromBody] BankAccountDto a)
    {
        var existingAccount = BankAccounts.FirstOrDefault(x => x.Id == id);
        if (existingAccount == null)
        {
            return NotFound();
        }

        existingAccount.AccountName = a.AccountName;
        existingAccount.AccountNumber = a.AccountNumber;
        existingAccount.Balance = a.Balance;

        return Ok("Bank account updated successfully");
    }

    [HttpDelete("/api/bankaccount/{id}")]
    public IActionResult Delete(int id)
    {
        var account = BankAccounts.FirstOrDefault(x => x.Id == id);
        if (account == null)
        {
            return NotFound();
        }

        BankAccounts.Remove(account);
        return Ok("Bank account deleted successfully");
    }
}

public class BankAccountDto
{
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}

public class BankAccountFilterDto
{
    public string? AccountName { get; set; }
    public string? AccountNumber { get; set; }
}

public class BankAccount
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}