import { configureStore } from '@reduxjs/toolkit';
import destinacijaReducer from './../redux/destinacijaSlice';
import authReducer from "./../redux/authSlice"

const store = configureStore({
  reducer: {
    destinacije: destinacijaReducer,
    auth:authReducer // Dodajemo destinacija reducer u store
  },
});

export type RootState = ReturnType<typeof store.getState>; // Tipizovanje RootState
export type AppDispatch = typeof store.dispatch; // Tipizovanje Dispatch-a

export default store;
