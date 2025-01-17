using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimConsole;
using Simulator;
using Simulator.Maps;
using System.Drawing;
using System.Text.Json;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        private Simulation _simulation;
        private SimulationHistory _history;

        public int Turn { get; set; }
        public int MaxTurn { get; set; }
        public Dictionary<Point, char> Symbols { get; set; }
        public bool Finished { get; set; }

        public void OnGet()
        {

            if (_simulation == null)
            {
                InitializeSimulation();
            }

            Turn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;

            if (_history == null)
            {
                _history = new SimulationHistory(_simulation);
                _history.Run();
            }

            _history.CurrentTurn = Turn;

            if (_history.CurrentTurn >= 0 && _history.CurrentTurn < _simulation.Moves.Length)
            {
                var currentMove = _simulation.Moves[_history.CurrentTurn].ToString().ToLower();
            }
           

            UpdateState();
        }


        private void InitializeSimulation()
        {
            TorusMap map = new(8, 6);

            List<IMappable> mappables = new List<IMappable>
            {
                new Elf("Elandor"),
                new Orc("Gorbag"),
                new Rabbit("Rabbit1"),
                new Rabbit("Rabbit2"),
                new FlyingBird("Eagle1"),
                new FlyingBird("Eagle2"),
                new NonFlyingBird("Ostrich1"),
                new NonFlyingBird("Ostrich2")
            };

            List<Point> positions = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1),
                new Point(1, 1),
                new Point(4, 4),
                new Point(5, 0),
                new Point(0, 5),
                new Point(3, 3),
                new Point(6, 2)
            };

            _simulation = new Simulation(map, mappables, positions, "dldlurrld");
            _history = new SimulationHistory(_simulation);

            _history.Run();
        }

        private void UpdateState()
        {
            MaxTurn = _simulation.Moves.Length;

            Symbols = _history.GetSymbolsForCurrentTurn();
            Finished = _simulation.Finished;
        }

        public IActionResult OnGetNext()
        {
            if (_simulation == null)
            {
                InitializeSimulation();
            }

            Turn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;

            if (Turn < _simulation.Moves.Length - 1)
            {
                Turn++;
                _simulation.NextTurn();
                _history.CurrentTurn = Turn;
                _history.AddTurnLog("Next Turn", "Move");
                HttpContext.Session.SetInt32("CurrentTurn", Turn);
                UpdateState();
            }

            Symbols = _history.GetSymbolsForCurrentTurn();
            return Page();
        }

        public IActionResult OnGetPrevious()
        {
            if (_simulation == null || _history == null)
            {
                InitializeSimulation();
            }

            Turn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;

            if (Turn > 0)
            {
                Turn--;
                _simulation.PreviousTurn();
                _history.CurrentTurn = Turn;
                _history.RemoveLastTurnLog();
                HttpContext.Session.SetInt32("CurrentTurn", Turn);
                UpdateState();
            }

            Symbols = _history.GetSymbolsForCurrentTurn();
            return Page();
        }
    }

}
