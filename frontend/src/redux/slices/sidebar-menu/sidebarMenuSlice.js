import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    menuSelected: 1,
};

const sidebarSlice = createSlice({
  name: "sidebar",
  initialState,
  reducers: {
    setMenuSelected: (state, action) => {
      state.menuSelected = action.payload;
    },
  },
});
export const { setMenuSelected  } = sidebarSlice.actions;
export default sidebarSlice.reducer;