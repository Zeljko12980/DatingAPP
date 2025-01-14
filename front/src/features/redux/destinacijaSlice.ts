import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosError } from 'axios';

// Tipizovanje stanja
interface DestinacijaState {
  destinacije: Destinacija[];
  loading: boolean;
  error: string | null;
}

const initialState: DestinacijaState = {
  destinacije: [],
  loading: false,
  error: null,
};

// Definisanje tipa Destinacija
export interface Destinacija {
  image: string;
  title: string;
  subTitle: string;
  cost: string;
  duration: string;
}

// Kreiranje async thunk za poziv API-ja
export const fetchDestinacije = createAsyncThunk<Destinacija[], void>(
  'destinacije/fetchDestinacije',
  async () => {
    const response = await axios.get('http://localhost:5174/api/Destinacija');
    return response.data;
  }
);

const destinacijaSlice = createSlice({
  name: 'destinacije',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchDestinacije.pending, (state) => {
        state.loading = true; // Kada poziv počne
      })
      .addCase(fetchDestinacije.fulfilled, (state, action: PayloadAction<Destinacija[]>) => {
        state.loading = false; // Kada poziv završi
        state.destinacije = action.payload; // Postavljaju se podaci
        state.error = null; // Nema greške
      })
      .addCase(fetchDestinacije.rejected, (state, action) => {
        state.loading = false; // Kada poziv nije uspešan
        // Definisanje greške sa AxiosError
        if (action.error instanceof AxiosError && action.error.response) {
          state.error = `Error: ${action.error.response.status}`;
        } else {
          state.error = action.error.message || 'Failed to fetch destinacije'; // Predefinisana greška
        }
      });
  },
});

export default destinacijaSlice.reducer;
