using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuzzyBox_Web_Api.Data;
using BuzzyBox_Web_Api.Models;
using BuzzyBox_Web_Api.Vm_Model;

namespace BuzzyBox_Web_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TransactionsController : ControllerBase
  {
    private readonly DataContext _context;

    public TransactionsController(DataContext context)
    {
      _context = context;
    }

    // GET: api/Transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transactionvm>>> GetTransactions()
    {
      var VMTransactionlist = new List<Transactionvm>();
      var TransactionList = _context.Transactions.ToList();
      foreach (var Transaction in TransactionList)
      {
        var isTransaction = new Transactionvm();
        isTransaction.TransactionId = Transaction.TransactionId;
        isTransaction.Transactiontype = Transaction.Transactiontype;
        isTransaction.Transactiontime = Transaction.Transactiontime;
        isTransaction.Transactiondate = Transaction.Transactiondate;
        isTransaction.Transactionamount = Transaction.Transactionamount;
        isTransaction.TransactiontypeId = Transaction.TransactiontypeId;
        if (Transaction.TransactiontypeId != 0 && Transaction.TransactiontypeId != null)
        {
          isTransaction.Transactiontypename = _context.Transactiontypes.Find(Transaction.TransactiontypeId).Transactiontypename;
        }
        VMTransactionlist.Add(isTransaction);
      }
      return VMTransactionlist;
    }









    // GET: api/Transactions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Transactionvm>> GetTransaction(int id)
    {

      var VMTransactionlist = new List<Transactionvm>();
      var Transaction = await _context.Transactions.FindAsync(id);

      if (Transaction != null) ;
      {
          
          var isTransaction = new Transactionvm();
          isTransaction.TransactionId = Transaction.TransactionId;
           isTransaction.Transactiontype = Transaction.Transactiontype;
          isTransaction.Transactiontime = Transaction.Transactiontime;
          isTransaction.Transactiondate = Transaction.Transactiondate;
          isTransaction.Transactionamount = Transaction.Transactionamount;
           isTransaction.TransactiontypeId = Transaction.TransactiontypeId;
           if (Transaction.TransactiontypeId != 0 && Transaction.TransactiontypeId != null)
           {
              isTransaction.Transactiontypename = _context.Transactiontypes.Find(Transaction.TransactiontypeId).Transactiontypename;

           }
           VMTransactionlist.Add(isTransaction);
      }
      return Ok(VMTransactionlist);
    }
      



  

  // PUT: api/Transactions/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
  {
    if (id != transaction.TransactionId)
    {
      return BadRequest();
    }

    _context.Entry(transaction).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!TransactionExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  // POST: api/Transactions
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
  {
    _context.Transactions.Add(transaction);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
  }

  // DELETE: api/Transactions/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTransaction(int id)
  {
    var transaction = await _context.Transactions.FindAsync(id);
    if (transaction == null)
    {
      return NotFound();
    }

    _context.Transactions.Remove(transaction);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool TransactionExists(int id)
  {
    return _context.Transactions.Any(e => e.TransactionId == id);
  }


}
}
