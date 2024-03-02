using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mission08_Team4_3.Models
{
    public class EFTodoRepository : ITodoRepository
    {
        private TodosContext _context;
        public EFTodoRepository(TodosContext temp)
        {
            _context = temp;
        }

        public List<Todo> Todos => _context.Todos.ToList();

        public void AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }
        public void RemoveTodo(Todo todo)
        {
            _context.Remove(todo);
            _context.SaveChanges();
        }
        public void UpdateTodo(Todo todo)
        {
            _context.Update(todo);
            _context.SaveChanges();
        }



        // Make up Classes ***I am not sure about these below




        public List<Todo> GetIncompleteTodosWithCategory()
        {
            return _context.Todos.Where(t => t.Completed == false).ToList();
        }
        public Todo GetTodoById(int taskId)
        {
            var todo = _context.Todos
                .FirstOrDefault(t => t.TaskId == taskId);

            if (todo == null)
            {
                throw new InvalidOperationException($"No Todo found with ID {taskId}.");
            }

            return todo;
        }


        public void ToggleCompletionStatus(int taskId)
        {
            var task = _context.Todos.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Completed = !task.Completed;
                _context.SaveChanges();
            }
        }
    }
}

