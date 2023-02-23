import { createSlice } from "@reduxjs/toolkit";

const initialState = {
	adminInfo: {}, // for user object
	// adminRole: "", 
	isLoggedIn: false,
};

const userSlice = createSlice({
	name: "user",
	initialState,
	reducers: {
		login: (state, action) => {
			// state.adminRole = action.payload.role;
			state.adminInfo = action.payload;
			state.isLoggedIn = true;
		},
		logout: (state) => {
			state.isLoggedIn = false;
			// state.adminRole = "";
			state.adminInfo = {};
			
		},
	},
	extraReducers: {},
});

export const { login, logout } = userSlice.actions;

export default userSlice.reducer;
