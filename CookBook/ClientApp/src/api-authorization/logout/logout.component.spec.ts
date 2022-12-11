import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import {
  ActivatedRoute,
  convertToParamMap,
  Params,
  UrlSegment,
} from "@angular/router";
import { HomeComponent } from "src/app/components/home/home.component";
import { LogoutComponent } from "./logout.component";
import { LogoutActions } from "../api-authorization.constants";

describe("LogoutComponent", () => {
  let component: LogoutComponent;
  let fixture: ComponentFixture<LogoutComponent>;

  beforeEach(async(() => {
    const tempParams: Params = { id: "1234" };

    const segment0: UrlSegment = new UrlSegment("segment0", {});
    const segment1: UrlSegment = new UrlSegment(LogoutActions.LoggedOut, {});

    const urlSegments: UrlSegment[] = [segment0, segment1];

    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          {
            path: "authentication/login-failed",
            component: HomeComponent,
          },
        ]),
      ],
      declarations: [LogoutComponent, HomeComponent],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: convertToParamMap(tempParams),
              url: urlSegments,
              queryParams: tempParams,
            },
          },
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
