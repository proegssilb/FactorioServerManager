import Button from 'react-bootstrap/Button';
import Image from 'react-bootstrap/Image';
import { useAuth, preloadUser } from 'reactfire'

function LoginBox() {
    preloadUser({});
    
    const auth = useAuth();
    const googleProvider = new useAuth.GoogleAuthProvider();
    const githubProvider = new useAuth.GithubAuthProvider();
    
    function googleAuth() {
        auth.signInWithPopup(googleProvider);
    }
    
    function githubAuth() {
        auth.signInWithPopup(githubProvider)
    }
    
    return <div>
        <Button type="button" onClick={googleAuth} > Login with Google <Image id="google-login-icon" src="/google-login.svg" rounded fluid /> </Button>
        &nbsp;
        <Button type="button" onClick={githubAuth} > Login with Github <Image id="github-login-icon" src="/github-login.svg" rounded fluid /> </Button>
    </div>;
}

export default LoginBox;
