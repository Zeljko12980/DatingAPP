import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import { RootState } from './store'; // Importujte root reducer

// Tipizovani useDispatch i useSelector
export const useAppDispatch = () => useDispatch();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
