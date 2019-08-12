using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Data;
using System.Reflection;
using System.IO.Compression;
using Core.EntityFramework;
using System.Data.Entity.Core.Objects.DataClasses;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json.Serialization;

namespace Core.EntityFramework
{
    /// <summary>
    /// Version 20140714
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseManager<TEntity> : IDisposable where TEntity : class
    {
        public DbContext db;

        protected string ItemTextField = "Description";
        protected string ItemValueField = "Id";

        public BaseManager(DbContext dbc)
        {
            db = dbc;
            db.Configuration.AutoDetectChangesEnabled = false;
        }

        public BaseManager()
        {
            db = new DbContext("DBContainer");
            db.Configuration.AutoDetectChangesEnabled = false;
        }
        
        public virtual void Create(TEntity entity, string summary)
        {
            try
            {
                //db.Entry(entity).State = System.Data.Entity.EntityState.Detached;
                //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();

                SaveAudit(entity, Audits.TypeAction.Create, summary);
            }
            catch (Exception ex) {
                throw Helper.ExeptionsHandler(ex);
            }
        }

        public virtual void Update(TEntity entity, string summary)
        {
            if (summary == null || summary.Length == 0) return;

            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                SaveAudit(entity, Audits.TypeAction.Update, summary);
            }
            catch (Exception ex)
            {
                throw Helper.ExeptionsHandler(ex);
            }
        }

        public virtual void Delete(int Id)
        {
            try
            {
                var item = Get(Id);
                db.Set<TEntity>().Remove(item);
                db.SaveChanges();

                SaveAudit(item, Audits.TypeAction.Delete, null);
            }
            catch (Exception ex) {
                throw Helper.ExeptionsHandler(ex);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();

                SaveAudit(entity, Audits.TypeAction.Delete, null);
            }
            catch (Exception ex)
            {
                throw Helper.ExeptionsHandler(ex);
            }
        }

        public TEntity Get(int Id)
        {
            return db.Set<TEntity>().Find(Id);            
        }

        public TEntity Get(string Id)
        {
            return db.Set<TEntity>().Find(Id);            
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> rdo = null != where ? db.Set<TEntity>().Where(where) : db.Set<TEntity>();
            return rdo;
        }

        protected void SaveAudit(TEntity entity, Audits.TypeAction Action, string summary)
        {
            string EntityName = entity.GetType().Name;
            if (EntityName.Length > 50)
                EntityName = entity.GetType().BaseType.Name;

            // Get Id Value
            PropertyInfo prop = entity.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);

            try
            {
                //int? keyValue = (int?)prop.GetValue(entity, null);

                //SaveAudit(EntityName, keyValue.HasValue ? keyValue.Value : -1, Action, summary);
            }
            catch
            { }
        }

        protected void SaveAudit(string EntityName, int EntityId, Audits.TypeAction Action, string summary)
        {
            try
            {
                //int? UserId = ((Mondelez.Security.Security_WS.UserDTO)System.Web.HttpContext.Current.Session["DomainUser"]).Id;

                //Audits.SaveAudit(Mondelez.Framework.Web.Helper.ApplicationId(), EntityId, EntityName, Action, UserId, Environment.MachineName, summary);
            }
            catch
            { }
        }

        /*public static T CopyEntity<T>(DbContext ctx, T entity, bool copyKeys = false) where T : EntityObject
        {            
            T clone = ctx.CreateObject<T>();
            PropertyInfo[] pis = entity.GetType().GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                EdmScalarPropertyAttribute[] attrs = (EdmScalarPropertyAttribute[])pi.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false);

                foreach (EdmScalarPropertyAttribute attr in attrs)
                {
                    if (!copyKeys && attr.EntityKeyProperty)
                        continue;

                    pi.SetValue(clone, pi.GetValue(entity, null), null);
                }
            }

            return clone;
        }*/



        public static T CloneJson<T>(T source)
        {
            try
            {
                //return ReferenceEquals(source, null) ? default(T) : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
                return ReferenceEquals(source, null) ? default(T) : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }));
            }
            catch (JsonSerializationException jsex)
            {
                throw jsex;
            }

            catch (JsonException jex)
            {
                throw jex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
        /*
        public static T DeepClone<T>(T source)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new MyContractResolver() };
            var serialized = JsonConvert.SerializeObject(source, Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public class MyContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                .Select(p => base.CreateProperty(p, memberSerialization))
                            .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                        .Select(f => base.CreateProperty(f, memberSerialization)))
                            .ToList();
                props.ForEach(p => { p.Writable = true; p.Readable = true; });
                return props;
            }
        }

        */
        /// <summary>
        /// Clone and returns changes
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        protected string CopyObject(TEntity From, TEntity To, string notCopyProperty = null)
        {
            string summary = string.Empty;

            PropertyInfo[] props = To.GetType().GetProperties();
            //var props = To.GetType().GetProperties(
            //BindingFlags.DeclaredOnly |
            //BindingFlags.Public |
            //BindingFlags.Instance)
            //.Where(p => !p.PropertyType.IsClass)
            //;

            
            //var keyNames = db.Set.EntitySet.ElementType.KeyMembers.Select(k => k.Name);

            foreach (PropertyInfo pTo in props)
            {
                //Busca que el objeto pertenezca el namespace Hubble
                if (pTo.PropertyType.Name.Contains("ICollection") || !pTo.PropertyType.FullName.Contains("System."))
                {
                    //deberia hacer recursividad en los objetos hijos pero bue...
                    //PropertyInfo[] propsChild = pTo.GetType().GetProperties();
                    //foreach (PropertyInfo pToChild in propsChild)
                    //{
                        
                    //}
                        
                        continue;
                }

                PropertyInfo pFrom = From.GetType().GetProperty(pTo.Name, BindingFlags.Public | BindingFlags.Instance);

                //No copiamos la propiedad cuando notCopyProperty tenga algún valor
                 if (string.IsNullOrEmpty(notCopyProperty) || !EqualsIgnoreCase(pTo.Name, notCopyProperty))
                {
                    // Si cambio a null
                    if (pFrom.GetValue(From, null) == null && pTo.GetValue(To, null) != null)
                    {
                        summary += "Change " + pTo.Name + ". Old: " + pTo.GetValue(To, null) + Environment.NewLine;
                        pTo.SetValue(To, null, null);
                    }
                    // Si era null
                    else if (pFrom.GetValue(From, null) != null && pTo.GetValue(To, null) == null)
                    {
                        summary += "Change " + pTo.Name + ". Old: null" + Environment.NewLine;
                        pTo.SetValue(To, pFrom.GetValue(From, null), null);
                    }
                    else if (pFrom.GetValue(From, null) == null && pTo.GetValue(To, null) == null)
                    {
                        //Bug fix
                    }
                    // Compara los datos
                    else if (pFrom.GetValue(From, null).ToString() != pTo.GetValue(To, null).ToString())
                    {
                        summary += "Change " + pTo.Name + ". Old: " + pTo.GetValue(To, null) + Environment.NewLine;

                        //Hacemos esta validación porque podemos tener clases que no implementen la propiedad Set
                        //Ejemplo: en ModelUpdates tenemos EfectivoNew que pertenece a Temp_CompraVentaPrecAdq
                        //y es un campo autocalculado, no existe en la tabla
                        if (pTo.CanWrite)
                        {
                            pTo.SetValue(To, pFrom.GetValue(From, null), null);
                        }
                    }
                }
            }

            return summary;
        }

        public static bool EqualsIgnoreCase(string a, string b)
        {
            int resultado = string.Compare(a, b, StringComparison.InvariantCultureIgnoreCase);
            //return Regex.IsMatch(a, b, RegexOptions.IgnoreCase);
            if (resultado == 0)
                return true;
            else
                return false;
        }

        public virtual IEnumerable<Core.Framework.ItemDTO> GetItemDTO()
        {

            throw new NotImplementedException();

            //return db.Set<TEntity>().Select(x => new Mondelez.Framework.ItemDTO()
            //    {
            //        //IntValue = x.Id,
            //        //Text = x.Descripcion
            //    }
            //).OrderBy(x => x.Text).ToList();
        }

        public virtual void Save(TEntity entity, string summary)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
        
    }

   
}
