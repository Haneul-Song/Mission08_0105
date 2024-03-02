
using Microsoft.EntityFrameworkCore;
using Mission08_0105.Models;
using System.Threading.Tasks;

namespace Mission08_0105
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
            _context.Add(todo);
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


        public List<Todo> GetIncompleteTodosWithCategory()
        {
            return _context.Todos.Where(t => t.Completed == 0).ToList();
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
                task.Completed = task.Completed == 0 ? 1 : 0;
                _context.SaveChanges();
            }
        }
    }
}
