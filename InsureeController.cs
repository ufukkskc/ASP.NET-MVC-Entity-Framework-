using Microsoft.AspNetCore.Mvc;

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(Insuree insuree)
{
    if (ModelState.IsValid)
    {
        decimal quote = 50m;

        // Calculate age
        var today = DateTime.Today;
        int age = today.Year - insuree.DateOfBirth.Year;
        if (insuree.DateOfBirth > today.AddYears(-age)) age--;

        // Age-based adjustments
        if (age <= 18)
        {
            quote += 100;
        }
        else if (age >= 19 && age <= 25)
        {
            quote += 50;
        }
        else
        {
            quote += 25;
        }

        // Car year
        if (insuree.CarYear < 2000)
        {
            quote += 25;
        }
        if (insuree.CarYear > 2015)
        {
            quote += 25;
        }
        public ActionResult Admin()
{
    var allInsurees = db.Insurees.ToList();
    return View(allInsurees);
}


// Car make/model
if (insuree.CarMake != null && insuree.CarMake.ToLower() == "porsche")
        {
            quote += 25;

            if (insuree.CarModel != null && insuree.CarModel.ToLower() == "911 carrera")
            {
                quote += 25;
            }
        }

        // Speeding tickets
        quote += insuree.SpeedingTickets * 10;

        // DUI check
        if (insuree.DUI)
        {
            quote *= 1.25m;
        }

        // Coverage type check
        if (insuree.CoverageType) // true = full coverage
        {
            quote *= 1.5m;
        }

        // Assign the final quote
        insuree.Quote = quote;

        // Save to DB
        db.Insurees.Add(insuree);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(insuree);
}
