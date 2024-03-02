namespace Mission08_0105.Models
{
    public interface ITodoRepository
    {
        List<Todo> Todos { get; }

        public void AddTodo(Todo todo);
        public void RemoveTodo(Todo todo);
        public void UpdateTodo(Todo todo);
        List<Todo> GetIncompleteTodosWithCategory();
        public Todo GetTodoById(int taskId);
        public void ToggleCompletionStatus(int taskId);

    }
}
