using System;
using System.Windows.Forms;

namespace EasyAsDriverTraining.Tools
{
    public static class GridView
    {
        public static void KeyUpDown(DataGridView dgView, Keys key)
        {
            try
            {
                if (dgView.Rows.Count <= 0)
                    return;
                dgView.Focus();
                var selIndex = dgView.SelectedRows[0].Index;
                var newSelIndex = selIndex + 1;
                if (key == Keys.Down)
                {
                    if (newSelIndex >= dgView.Rows.Count)
                        return;
                }
                else
                {
                    newSelIndex = selIndex - 1;
                    if (newSelIndex < 0)
                        return;
                }

                dgView.Rows[selIndex].Selected = false;
                dgView.Rows[newSelIndex].Selected = true;
                dgView.Rows[newSelIndex].Cells[0].Selected = true;

                dgView.CurrentCell = dgView.Rows[newSelIndex].Cells[0].Visible ? dgView.Rows[newSelIndex].Cells[0] : dgView.Rows[newSelIndex].Cells[1];

                if (newSelIndex == 0)
                    dgView.FirstDisplayedScrollingRowIndex = 0;
                else
                {
                    if (key == Keys.Down)
                    {
                        if (dgView.FirstDisplayedScrollingRowIndex + dgView.DisplayedRowCount(false) <= newSelIndex)
                        {
                            dgView.FirstDisplayedScrollingRowIndex =
                                newSelIndex - dgView.DisplayedRowCount(false) + 1;
                        }
                    }
                    else
                    {
                        if (newSelIndex == 1)
                            return;

                        if (dgView.FirstDisplayedScrollingRowIndex > newSelIndex)
                        {
                            dgView.FirstDisplayedScrollingRowIndex =
                                newSelIndex - 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void SelectLastRow(DataGridView dgView)
        {
            try
            {
                if (dgView.Rows.Count < 1) return;
                dgView.Focus();
                dgView.ClearSelection();
                var newSelIndex = dgView.Rows.Count - 1;
                dgView.Rows[newSelIndex].Selected = true;
                dgView.Rows[newSelIndex].Cells[0].Selected = true;
                if (dgView.FirstDisplayedScrollingRowIndex + dgView.DisplayedRowCount(false) <= newSelIndex)
                {
                    dgView.FirstDisplayedScrollingRowIndex =
                        newSelIndex - dgView.DisplayedRowCount(false) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void RemLastRow(DataGridView dgView, int lastSavedRow, int lastSavedIndex)
        {
            try
            {
                if (dgView.Rows.Count < 1) return;
                dgView.Focus();
                dgView.ClearSelection();
                dgView.Rows[lastSavedRow].Selected = true;
                dgView.Rows[lastSavedRow].Cells[0].Selected = true;
                dgView.FirstDisplayedScrollingRowIndex = lastSavedIndex;
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }
    }
}

