namespace Northwind.Logic.Model
{
    public class ProjectDto
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Price { get; private set; }
        public string Stage { get; private set; }

        public ProjectDto(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Price = project.Price.ToString("C0");
            Stage = project.Stage.ToString();
        }
    }
}
