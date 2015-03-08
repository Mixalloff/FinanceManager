﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;


namespace FinanceManager.Models.Repositories
{
    /// <summary>
    /// Универсальный репозиторий, содержащий базовые CRUD операции
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public class AbstractRepository<T> where T : class, new()
    {
        /// <summary>
        /// Возвращает все сущности класса T из БД
        /// </summary>
        /// <returns>Список сущностей</returns>
        public virtual IEnumerable<T> GetAll()
        {
            using (var context = new FinanceManagerDb())
            {
                return context.Set<T>().ToList();
            }
        }

        /// <summary>
        /// Сохраняет все изменения в БД
        /// </summary>
        /// <param name="context">Контекст БД</param>
        public virtual void Save(FinanceManagerDb context)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает сущность по заданному идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Найденная сущность</returns>
        public virtual T FindById(int id)
        {
            using (var context = new FinanceManagerDb())
            {
                return context.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// Создание новой сущности
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>Сущность, которая была добавлена в БД</returns>
        public virtual T Create(T entity)
        {
            using (var context = new FinanceManagerDb())
            {
                context.Entry(entity).State = EntityState.Added;
                this.Save(context);
            }

            return entity;
        }

        /// <summary>
        /// Удаление выбранной сущности
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        public virtual void Delete(T entity)
        {
            using (var context = new FinanceManagerDb())
            {
                context.Entry(entity).State = EntityState.Deleted;
                this.Save(context);
            }
        }

        /// <summary>
        /// Обновляет выбранную сущность
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        public virtual void Update(T entity)
        {
            using (var context = new FinanceManagerDb())
            {
                context.Set<T>().AddOrUpdate(entity);
                this.Save(context);
            }
        }
    }
}