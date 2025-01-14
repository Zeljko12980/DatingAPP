import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';

// Definisanje AuthState interfejsa
interface AuthState {
  token: string | null;
  isLoading: boolean;
  error: string | null;
  isLogged:boolean;
}

// Async Thunk za login
export const login = createAsyncThunk(
  'auth/login',
  async (
    { username, password }: { username: string; password: string },
    { rejectWithValue }
  ) => {
    try {
      const response = await axios.post(
        `http://localhost:5174/api/User/login?username=${username}&password=${password}`
      );

      // Pretpostavlja se da server vraća token u odgovoru
      const { token } = response.data;

      // Čuvanje tokena u lokalnoj memoriji (opcionalno)
      localStorage.setItem('token', token);

      return { token }; // Vraćamo samo token jer user nije deo odgovora
    } catch (error: any) {
      return rejectWithValue(error.response?.data || 'Došlo je do greške.');
    }
  }
);

// Početno stanje
const initialState: AuthState = {
  token: null,
  isLoading: false,
  error: null,
  isLogged:false,
};

// Slice
const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    logout: (state) => {
      state.token = null;
      localStorage.removeItem('token'); 
      state.isLogged=false;// Uklanjanje tokena
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(login.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(login.fulfilled, (state, action: PayloadAction<{ token: string }>) => {
        state.isLoading = false;
        state.token = action.payload.token;
        state.error = null;
        state.isLogged=true;
      })
      .addCase(login.rejected, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        state.error = action.payload;
      });
  },
});

// Exportovanje reducera i akcija
export const { logout } = authSlice.actions;
export default authSlice.reducer;
