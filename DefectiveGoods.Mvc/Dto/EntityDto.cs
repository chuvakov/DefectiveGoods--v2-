namespace DefectiveGoods.Mvc.Dto
{
    public abstract class EntityDto<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
