namespace ITransitionTask4.DataTransferObjects
{
    public record UserDto
    {
        public string? Id { get; set; }
        public string? Name { get; init; }
        public DateTime? RegisterDate { get; init; }
        public DateTime? LastLoginDate { get; init; }
        public string? Status { get; init; }
    }
}
