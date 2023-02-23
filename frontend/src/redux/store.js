import { combineReducers, configureStore } from "@reduxjs/toolkit";
import userReducer from "./slices/user/userSlice";
import SidebarReducer from "./slices/sidebar-menu/sidebarMenuSlice"
import storage from 'redux-persist/lib/storage/session'
import LoaderReducer from './slices/loading/loaderSlice'
import { persistReducer, persistStore } from "redux-persist";
import thunk from "redux-thunk";

const persistConfig = {
	key: "root",
	storage,
};

const persistedReducer = persistReducer(
	persistConfig,
	combineReducers({ user: userReducer, sidebar :SidebarReducer ,loader: LoaderReducer })
);

const store = configureStore({
	reducer: persistedReducer,
	middleware: [thunk],
});

const persistor = persistStore(store);
export { store, persistor };