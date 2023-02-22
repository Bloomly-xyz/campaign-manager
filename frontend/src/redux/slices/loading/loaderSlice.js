import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  loadingState: false,
};

const loaderSlice = createSlice({
  name: "loader",
  initialState,
  reducers: {
    setLoader: (state, action) => {
      state.loadingState = action.payload;
    },
  },
});
export const { setLoader } = loaderSlice.actions;
export default loaderSlice.reducer;