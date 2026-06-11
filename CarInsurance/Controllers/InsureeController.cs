using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;
using CarInsurance.Data;

public class InsureeController : Controller
{
    private readonly InsureeContext _context;

    public InsureeController(InsureeContext context)
    {
        _context = context;
    }

    // GET: INSUREES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Insurees.ToListAsync());
    }

    // GET: INSUREES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // GET: INSUREES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: INSUREES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Birthdate,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            // Start with a base of $50 / month
            decimal monthlyTotal = 50m;

            // Calculate age using your "Birthdate" property
            int age = DateTime.Today.Year - insuree.Birthdate.Year;
            if (insuree.Birthdate.Date > DateTime.Today.AddYears(-age)) age--;

            // Age logic
            if (age <= 18)
            {
                monthlyTotal += 100m;
            }
            else if (age >= 19 && age <= 25)
            {
                monthlyTotal += 50m;
            }
            else if (age >= 26)
            {
                monthlyTotal += 25m;
            }

            // Car year logic
            if (insuree.CarYear < 2000)
            {
                monthlyTotal += 25m;
            }
            else if (insuree.CarYear > 2015)
            {
                monthlyTotal += 25m;
            }

            // Car Make and Model logic
            if (insuree.CarMake != null && insuree.CarMake.Trim().Equals("Porsche", StringComparison.OrdinalIgnoreCase))
            {
                monthlyTotal += 25m;
                if (insuree.CarModel != null && insuree.CarModel.Trim().Equals("911 Carrera", StringComparison.OrdinalIgnoreCase))
                {
                    monthlyTotal += 25m;
                }
            }

            // Speeding ticket logic ($10 per ticket)
            monthlyTotal += (insuree.SpeedingTickets * 10m);

            // DUI logic (add 25%)
            if (insuree.DUI)
            {
                monthlyTotal += (monthlyTotal * 0.25m);
            }

            // Coverage Type logic (checks if the text contains "full")
            if (insuree.CoverageType != null && insuree.CoverageType.Contains("full", StringComparison.OrdinalIgnoreCase))
            {
                monthlyTotal += (monthlyTotal * 0.50m);
            }

            // Save total to the model
            insuree.Quote = monthlyTotal;

            _context.Add(insuree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(insuree);
    }

    // GET: INSUREES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree == null)
        {
            return NotFound();
        }
        return View(insuree);
    }

    // POST: INSUREES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,Email,Birthdate,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (id != insuree.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(insuree);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsureeExists(insuree.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(insuree);
    }

    // GET: INSUREES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // POST: INSUREES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree != null)
        {
            _context.Insurees.Remove(insuree);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InsureeExists(int? id)
    {
        return _context.Insurees.Any(e => e.Id == id);
    }

    // GET: Insurees/Admin
    public async Task<IActionResult> Admin()
    {
        return View(await _context.Insurees.ToListAsync());
    }
}
