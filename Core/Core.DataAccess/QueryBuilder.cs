﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DataAccess
{
    public class QueryBuilder
    {
        public class Item
        {
            private string m_Campo;
            private string m_Valor;
            private Type m_Tipo;
            private bool m_allowDBNull;

            public string Campo
            {
                get { return m_Campo; }
                set { m_Campo = value; }
            }

            public string Valor
            {
                set { 
                    m_Valor = value; 
                }
                get
                {
                    return SqlValor();
                }
            }

            public Type Tipo
            {
                get { return m_Tipo; }
                set { m_Tipo = value; }
            }

            public Item()
            { }

            public Item(string Campo, Type Tipo, bool AllowDBNull, string Valor)
            {
                m_Campo = Campo;
                m_Valor = Valor;
                this.Tipo = Tipo;
                m_allowDBNull = AllowDBNull;
            }

            public Item(string Campo, string Valor)
            {
                m_Campo = Campo;
                m_Valor = Valor;
                this.Tipo = typeof(string);
                m_allowDBNull = true;
            }

            private string SqlValor()
            {
                string result = "";

                if (Tipo == typeof(string) || Tipo == typeof(System.Decimal))
                    result = "'" + m_Valor + "'";
                else if (Tipo == typeof(System.Int32) || Tipo == typeof(System.Int16) || Tipo == typeof(byte))
                {
                    if (m_Valor == "")
                    {
                        if (m_allowDBNull)
                            return "NULL";
                        else
                            return "0";
                    }
                    else
                        return m_Valor;
                }
                else if (Tipo == typeof(double) || Tipo == typeof(float))
                {
                    if (m_Valor == null || m_Valor == "")
                    {
                        if (m_allowDBNull)
                            return "NULL";
                        else
                            return "0";
                    }
                    else
                        return m_Valor.Replace(",", ".");
                }
                else if (Tipo == typeof(DateTime))
                {
                    if (m_Valor == null || m_Valor == "")
                    {
                        if (m_allowDBNull)
                            return "NULL";
                        else
                            return "'19000101'";
                    }
                    else
                        return "'" + m_Valor + "'";
                }
                else if (Tipo == typeof(Boolean))
                {
                    if (m_Valor == null || m_Valor == "")
                    {
                        if (m_allowDBNull)
                            return "NULL";
                        else
                            return "0";
                    }
                    else if (m_Valor == "True")
                        return "1";
                    else if (m_Valor == "False")
                        return "0";
                }
                else if (Tipo == typeof(System.DBNull))
                    return "NULL";

                return result;
            }

        }

        public abstract class Base
        {
            public List<Item> Items = new List<Item>();
            public string Table = string.Empty;
            public string Where = string.Empty;
            public abstract string GetQuery();

            public void ClearItems()
            {
                Items = new List<Item>();
                Where = string.Empty;
            }

        }

        public class Insert : Base
        {
            public override string GetQuery()
            {
                string result = "INSERT INTO " + Table + " (";

                foreach (Item i in Items)
                    result += i.Campo + ", ";
                result = result.Substring(0, result.Length - 2);

                result += ") VALUES (";
                foreach (Item i in Items)
                    result += i.Valor + ", ";

                result = result.Substring(0, result.Length - 2);

                result += ") ";
                return result;
            }
        }

        public class Update : Base
        {
            public override string GetQuery()
            {
                string result = "UPDATE [" + Table + "] SET ";

                foreach (Item i in Items)
                    result += i.Campo + "= " + i.Valor + ", ";
                result = result.Substring(0, result.Length - 2);

                if (Where != string.Empty) result += " WHERE " + Where;

                return result;
            }
        }

        public class Delete : Base
        {
            public override string GetQuery()
            {
                string result = "DELETE FROM " + Table + " WHERE ";

                if (Items.Count == 0)
                    return "";

                foreach (Item i in Items)
                    result += i.Campo + "= " + i.Valor + " AND ";
                result = result.Substring(0, result.Length - 5);

                return result;
            }
        }
    }
}

