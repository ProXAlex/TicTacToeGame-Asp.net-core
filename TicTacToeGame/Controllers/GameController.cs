using Microsoft.AspNetCore.Mvc;
using TicTacToeGame.Infrastructure;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{

    [Route("api/[controller]/[action]/{cellId?}/{withBot?}")]
    public class GameController : Controller
    {


        [HttpPost]
        public MoveResult Init()
        {
            Field field = GetField();
            MoveResult result = new MoveResult();

            if (field.IsEnd)
                return result;

            result.Cells = field.Cells;
            
            return result;
        }

        [HttpPost]
        public MoveResult Move(int cellId)
        {
            Field field = GetField();

            

            var result = field.Move(cellId);
            SaveField(field);

            return result;
        }

        private Field GetField()
        {
            Field field = HttpContext?.Session.GetJson<Field>("Field") ?? new Field();
            return field;
        }

        private void SaveField(Field field)
        {
            HttpContext.Session.SetJson("Field", field);
        }
    }
}