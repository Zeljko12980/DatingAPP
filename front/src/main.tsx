
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { Provider } from 'react-redux'
import store from './features/store/store.ts'

createRoot(document.getElementById('root')!).render(
 
    <Provider store={store}> {/* Omotava celu aplikaciju */}
    <App />
  </Provider>

)
