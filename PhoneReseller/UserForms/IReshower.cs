namespace LicenseGenerator.UserForms
{
    /// <summary>
    /// Итрефйес декларирует возможновть повтоного показа формы для разных данных
    /// </summary>
    public interface IReshower
    {
        /// <summary>
        /// Показать форму с заданными из row. Вернуть заполненные данные или null, если пользователь отменил ввод
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        ColumnsDictionary ShowMe(ColumnsDictionary row);
    }
}
