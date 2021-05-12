import LandingHome from './landing';
import { useUser } from 'reactfire';
import '@firebase/auth';
 
export default function Home() {
    const { data: user } = useUser();
    if (user) {
        return <div>Authenticated home page.</div> ;
    } else {
        return <LandingHome />
    }
}
