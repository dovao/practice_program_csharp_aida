using MySql.Data.MySqlClient;

namespace Checkout;

public class ReceiptRepository
{
    private const string DatabaseName = "myshop";
    private const string User = "store";
    private const string Pass = "123456";

    public static void Store(Receipt receipt)
    {
        using (var connection = new MySqlConnection
               {
                   ConnectionString = $"Database={DatabaseName};Data Source=localhost;User Id={User};Password={Pass}"
               })
        {
            connection.Open();
            using (var command = new MySqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                                  + "values (@amount, @tax, @total)", connection))
            {
                command.Parameters.AddWithValue("@amount", receipt.Amount.AsDecimal());
                command.Parameters.AddWithValue("@tax", receipt.Tax.AsDecimal());
                command.Parameters.AddWithValue("@total", receipt.Total.AsDecimal());
                command.ExecuteNonQuery();
            }
        }
    }
}