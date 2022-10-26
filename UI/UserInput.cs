using UI.Models;

namespace UI
{
    internal class UserInput
    {
        internal async Task GetInput()
        {
            Console.Clear();
            Console.WriteLine("Welcome to your shift tracker!");
            Console.WriteLine("A - Add a shift.");
            Console.WriteLine("S - See all your shifts.");
            Console.WriteLine("U - Update a shift.");
            Console.WriteLine("D - Delete a shift.");
            Console.WriteLine("E - Exit.");

            string input = Console.ReadLine();

            if (InputValidator.IsValidInput(input))
            {
                await ProcessSelectedOption(input);
            }
            else
            {
                Console.WriteLine("Please enter a valid input. Press enter to try again.");
                Console.ReadKey();
                await GetInput();
            }

        }

        private async Task ProcessSelectedOption(string input)
        {
            switch (input.ToUpper())
            {
                case "A":
                    await ProcessCreateShift();
                    break;
                case "S":
                    await ProcessViewShifts();
                    break;
                case "U":
                    await ProcessUpdateShift();
                    break;
                case "D":
                    await ProcessDeleteShift();
                    break;
                case "E":
                    Console.WriteLine("See you nex time!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please select a valid option. Press enter to go back");
                    Console.ReadKey();
                    await GetInput();
                    break;
            }
        }

        private async Task ProcessDeleteShift()
        {
            await ShowShifts();
            Console.WriteLine("Enter the id of the shift u want to delete.");
            string idStr = Console.ReadLine();
            if (InputValidator.IsValidNumber(idStr))
            {
                int id = int.Parse(idStr);
                var result = await ShiftService.Delete(id);
                if (result)
                    Console.WriteLine("Shift deleted sucesfully. Press any key to go back.");
                else
                    Console.WriteLine("There was an error when deleting the shift. press any key to go back.");
                Console.ReadKey();
                await GetInput();
            }
        }

        private async Task ProcessUpdateShift()
        {
            await ShowShifts();
            Console.WriteLine("Enter the id of the shift u want to update");
            string idStr = Console.ReadLine();
            if (InputValidator.IsValidNumber(idStr))
            {
                int id = int.Parse(idStr);
                Shift shift = CreateShift();
                shift.ShiftId = id;
                var result = await ShiftService.Update(shift);
                if (result)
                    Console.WriteLine("Shift updated sucesfully. Press any key to go back.");
                else
                    Console.WriteLine("There was an error when updating the shift. press any key to go back.");
                Console.ReadKey();
                await GetInput();
                
            }
        }

        private async Task ProcessViewShifts()
        {
            await ShowShifts();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
            await GetInput();
        }

        private async Task ShowShifts()
        {
            var shifts = await ShiftService.Get();
            TableVisualisation.ShowTable(shifts);
        }

        private async Task ProcessCreateShift()
        {
            Shift shift = CreateShift();
            await ProcessPost(shift);
        }

        private Shift CreateShift()
        {
            Console.WriteLine("Please enter the start time (yyyy/MM/dd hh:mm format) : ");
            DateTime startDate = Helpers.GetDate();
            Console.WriteLine("Please enter the end time (yyyy/MM/dd hh:mm format) : ");
            DateTime endDate = Helpers.GetDate();
            Console.WriteLine("Please enter the total payment.");
            decimal payment = Helpers.GetValidDecimal();
            Console.WriteLine("Please enter the location.");
            string location = Helpers.GetString();

            return new Shift() { End = endDate, Start = startDate, Location = location, Pay = payment };
        }

        private async Task ProcessPost(Shift shift)
        {
            var state = await ShiftService.Add(shift);
            if(state)
                Console.WriteLine("The shift was added sucesfully. Press enter to go back.");
            else
                Console.WriteLine("There was an error when adding the shift. Press enter to go back.");

            Console.ReadKey();
            await GetInput();
        }
    }
}